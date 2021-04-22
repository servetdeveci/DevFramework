using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.CrossCuttingConcerns.Logging;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace DevFramework.Core.Aspects.Postsharp.LogAspects
{
    [Serializable]

    // Constructorların değil sadece metodların loglanması için aşağıdaki kodu yazıyoruz
    [MulticastAttributeUsage(MulticastTargets.Method,TargetMemberAttributes = MulticastAttributes.Instance)]
    public class LogAspect:OnMethodBoundaryAspect
    {
        private Type _loggerType;
        private LoggerService _loggerService;

        public LogAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }


        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType.BaseType!=typeof(LoggerService))
            {
                throw new Exception("Wrong logger type");
            }
            // loggertype a göre bize bir instance oluşturuyor
            _loggerService = (LoggerService) Activator.CreateInstance(_loggerType);
            base.RuntimeInitialize(method);
        }


        /// <summary>
        /// logların ne zaman çalışacağı bize göre değişir.
        /// OnEntry de yani metoda ilk girildiğinde loglama metodunu cagırıyoruz
        /// </summary>
        /// <param name="args"></param>
        public override void OnEntry(MethodExecutionArgs args)
        {
            // Burada gelen logger service info enable deilse bu işlemi yapma
            if (!_loggerService.IsInfoEnabled)
            {
                return;
            }

            try
            {
                var logParameters = args.Method.GetParameters().Select((t, i) => new LogParameter
                {
                    Name = t.Name,
                    Type = t.ParameterType.Name,
                    Value = args.Arguments.GetArgument(i)
                }).ToList();

                var logDetail = new LogDetail
                {
                    FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                    MethodName = args.Method.Name,
                    Parameters = logParameters
                };

                _loggerService.Info(logDetail);
            }
            catch (Exception)
            {

            }
            
        }
    }
}
