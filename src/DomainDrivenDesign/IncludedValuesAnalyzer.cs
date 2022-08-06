using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Acidic.DomainDrivenDesign
{
    internal static class IncludedValuesAnalyzer
    {
        private const BindingFlags DefaultMemberBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
        
        public static object[] GetValuesInType<T>(Value<T> value) where T : Value<T>
        {
            return GetValuesInType(value, value.GetType(), new Dictionary<string, MemberStatus>()).ToArray();
        }

        private static IEnumerable<object> GetValuesInType<T>(Value<T> value, Type currentType, IDictionary<string, MemberStatus> overriddenMembers) where T : Value<T>
        {
            if (IsBaseValueType<T>(currentType))
            {
                return Enumerable.Empty<object>();
            }

            var extractFieldValuesTask = Task.Run(() =>
            {
                var fieldValues = currentType
                    .GetFields(DefaultMemberBindingFlags)
                    .Where(fieldInfo => IsNotCompilerGeneratedMember(fieldInfo) && MemberIsNotExcluded(fieldInfo))
                    .Select(fieldInfo => fieldInfo.GetValue(value));

                return fieldValues;
            });
            
            var extractPropertyValuesTask = Task.Run(() =>
            {
                var values = new List<object>();
                
                var propertyInfos = currentType.GetProperties(DefaultMemberBindingFlags);
                foreach (var propertyInfo in propertyInfos)
                {
                    if (IsPropertyBaseDefinition(propertyInfo))
                    {
                        var valueToInclude = HandleBaseDefinitionProperty(value, propertyInfo, ref overriddenMembers);
                        if (valueToInclude != null)
                        {
                            values.Add(valueToInclude);
                        }
                    }
                    else
                    {
                        HandleNonBaseDefinitionProperty(propertyInfo, ref overriddenMembers);
                    }
                }

                return new PropertiesAnalysisResult(values);
            });

            Task.WaitAll(extractFieldValuesTask, extractPropertyValuesTask);

            var baseValues = GetValuesInType(value, currentType.BaseType, overriddenMembers);

            return extractFieldValuesTask.Result
                .Concat(extractPropertyValuesTask.Result.Values)
                .Concat(baseValues);
        }

        private static object HandleBaseDefinitionProperty<T>(Value<T> value, PropertyInfo propertyInfo, ref IDictionary<string, MemberStatus> overriddenMembers) where T : Value<T>
        {
            try
            {
                if (overriddenMembers.TryGetValue(propertyInfo.Name, out var memberStatus))
                {
                    switch (memberStatus)
                    {
                        case MemberStatus.Exclude:
                            return null;
                        case MemberStatus.Include:
                            return propertyInfo.GetValue(value);
                    }
                }

                return MemberIsExcluded(propertyInfo)
                    ? null
                    : propertyInfo.GetValue(value);
            }
            finally
            {
                overriddenMembers.Remove(propertyInfo.Name);
            }
        }

        private static void HandleNonBaseDefinitionProperty(PropertyInfo propertyInfo, ref IDictionary<string, MemberStatus> overriddenMembers)
        {
            if (overriddenMembers.TryGetValue(propertyInfo.Name, out var memberStatus))
            {
                if (memberStatus != MemberStatus.Include)
                {
                    overriddenMembers[propertyInfo.Name] = GetMemberStatus(propertyInfo);
                }
            }
            else
            {
                overriddenMembers[propertyInfo.Name] = GetMemberStatus(propertyInfo);
            }
        }
        
        private class PropertiesAnalysisResult
        {
            public PropertiesAnalysisResult(IEnumerable<object> values)
            {
                Values = values;
            }

            public IEnumerable<object> Values { get; }
        }

        private enum MemberStatus
        {
            Neutral,
            Include,
            Exclude
        }
        
        private static bool IsBaseValueType<T>(Type type) where T : Value<T>
            => type == typeof(Value<T>);
        
        private static bool IsNotCompilerGeneratedMember(MemberInfo member) 
            => member.GetCustomAttribute(typeof(CompilerGeneratedAttribute)) is null;
        
        private static bool MemberIsIncluded(MemberInfo member) 
            => member.GetCustomAttribute<IncludeAttribute>() != null;
        
        private static bool MemberIsExcluded(MemberInfo member) 
            => member.GetCustomAttribute<ExcludeAttribute>() != null;
        
        private static bool MemberIsNotExcluded(MemberInfo member) 
            => !MemberIsExcluded(member);

        private static MemberStatus GetMemberStatus(MemberInfo member)
        {
            if (MemberIsExcluded(member))
            {
                return MemberStatus.Exclude;
            }

            if (MemberIsIncluded(member))
            {
                return MemberStatus.Include;
            }

            return MemberStatus.Neutral;
        }

        private static bool IsPropertyBaseDefinitionReal(PropertyInfo propertyInfo)
        {
            // It would be tempting to use this pattern to check if a property represents the base definition or not:
            //
            // 
            
            if (propertyInfo.GetMethod != null && propertyInfo.GetMethod.GetBaseDefinition() != propertyInfo.GetMethod)
            {
                return false;
            }
            
            if (propertyInfo.SetMethod != null && propertyInfo.SetMethod.GetBaseDefinition() != propertyInfo.SetMethod)
            {
                return false;
            }

            return true;
        }
        
        private static bool IsPropertyBaseDefinition(PropertyInfo propertyInfo)
        {
            if (propertyInfo.SetMethod?.GetBaseDefinition() != propertyInfo.SetMethod)
            {
                return false;
            }
            
            if (propertyInfo.GetMethod?.GetBaseDefinition() != propertyInfo.GetMethod)
            {
                return false;
            }

            return true;
        }
    }
}