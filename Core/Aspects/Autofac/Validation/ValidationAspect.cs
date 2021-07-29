using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensive codes //Type of u typeof(ProductValidator) yerine başka bir sey yazarsa hata alır kodu
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);  //reflaction //burası ProductValidator ı new ledi
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //product tipini yakala
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //add in parametrelerini gez
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);    //add de birden fazla product parametresi varsa onları burda gez
            }
        }
    }
}
