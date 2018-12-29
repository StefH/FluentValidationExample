using AutoMapper;
using FluentValidationExample.Common.Validation;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace FluentValidationExample.Web.Validation
{
    internal class FluentValidationPropertyNameResolver : IFluentValidationPropertyNameResolver
    {
        private readonly IMapper _mapper;

        private readonly IDictionary<(Type dtoType, string dtoProperty), string> _mappings = new Dictionary<(Type dtoType, string dtoProperty), string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentValidationPropertyNameResolver"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        public FluentValidationPropertyNameResolver([NotNull] IMapper mapper)
        {
            Guard.NotNull(mapper, nameof(mapper));

            _mapper = mapper;

            Init();
        }

        private void Init()
        {
            TypeMap[] allTypeMaps = _mapper.ConfigurationProvider.GetAllTypeMaps();
            foreach (TypeMap map in allTypeMaps)
            {
                foreach (PropertyMap propertyMap in map.PropertyMaps)
                {
                    string sourceMemberName = propertyMap.SourceMember?.Name;
                    _mappings.Add((map.DestinationType, propertyMap.DestinationName), sourceMemberName);
                }
            }
        }

        /// <inheritdoc cref="IFluentValidationPropertyNameResolver.Resolve(Type, MemberInfo, LambdaExpression)"/>
        public string Resolve(Type dtoType, MemberInfo dtoMemberInfo, LambdaExpression lambdaExpression)
        {
            (Type, string) key = (dtoType, dtoMemberInfo?.Name);

            if (_mappings.ContainsKey(key))
            {
                return _mappings[key];
            }

            return dtoMemberInfo?.Name;
        }
    }
}