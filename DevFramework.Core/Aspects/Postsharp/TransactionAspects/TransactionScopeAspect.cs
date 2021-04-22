using System;
using System.Transactions;
using PostSharp.Aspects;

namespace DevFramework.Core.Aspects.Postsharp.TransactionAspects
{
    [Serializable]
    public class TransactionScopeAspect:OnMethodBoundaryAspect
    {
        TransactionScopeOption _option;
        public TransactionScopeAspect(TransactionScopeOption option)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                _option = option;
            }
        }


        public TransactionScopeAspect()
        {
          
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = new TransactionScope(_option);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Complete();
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }

    }
}
