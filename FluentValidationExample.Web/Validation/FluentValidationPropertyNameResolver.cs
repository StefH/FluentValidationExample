using AutoMapper;
using FluentValidationExample.Common.Validation;
using JetBrains.Annotations;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace FluentValidationExample.Web.Validation
{
    internal class FluentValidationPropertyNameResolver : IFluentValidationPropertyNameResolver
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentValidationPropertyNameResolver"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        public FluentValidationPropertyNameResolver([NotNull] IMapper mapper)
        {
            Guard.NotNull(mapper, nameof(mapper));

            _mapper = mapper;
        }

        /// <inheritdoc cref="IFluentValidationPropertyNameResolver.Resolve(Type, MemberInfo, LambdaExpression)"/>
        public string Resolve(Type type, MemberInfo memberInfo, LambdaExpression lambdaExpression)
        {
            var allTypeMaps = _mapper.ConfigurationProvider.GetAllTypeMaps();

            var matchingTypeMaps = allTypeMaps.Where(m => m.DestinationType == type).ToArray();
            if (matchingTypeMaps.Length == 0 || matchingTypeMaps.Length > 1)
            {
                return memberInfo.Name;
            }

            var matchingTypeMap = matchingTypeMaps.First();
            var propertyMapping = matchingTypeMap.PropertyMaps.FirstOrDefault(pm => pm.DestinationName == memberInfo.Name);
            if (propertyMapping == null)
            {
                return memberInfo.Name;
            }

            return propertyMapping.SourceMember.Name;
        }
    }
}