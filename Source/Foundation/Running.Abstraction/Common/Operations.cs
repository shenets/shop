using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Running.Abstraction.Common
{
    public static class Operations
    {
        #region Constants
        private const string Binary = "Running.Realization";
        #endregion

        #region Data Members
        private static readonly Dictionary<string, Type> Repository = Operations.CreateRepository();
        #endregion

        #region Methods
        public static L Resolve<L>()
            where L : IOperations
        {
            try
            {
                string name = typeof(L).FullName;

                Type target = Operations.Repository[name];

                return (L)Activator.CreateInstance(target, true);
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException();
            }
        }
        #endregion

        #region Assistants
        private static Dictionary<string, Type> CreateRepository()
        {
            // Repository
            Dictionary<string, Type> repository = new Dictionary<string, Type>();

            Assembly assembly = Assembly.Load(Operations.Binary);
            List<Type> types = assembly.GetTypes().ToList();

            foreach (Type type in types)
            {
                List<Type> interfaces = type.GetInterfaces().ToList();

                if (interfaces.Contains(typeof(IOperations)) == true)
                {
                    Type abstraction = Operations.GetAbstraction(interfaces);

                    repository[abstraction.FullName] = type;
                }
            }

            return repository;
        }
        private static Dictionary<string, IOperations> CreateOperations<T>()
            where T : IOperations
        {
            Dictionary<string, IOperations> operations = new Dictionary<string, IOperations>();

            IEnumerable<Type> types = Operations.Repository.Values;
            foreach (Type type in types)
            {
                List<Type> interfaces = type.GetInterfaces().ToList();

                if (interfaces.Contains(typeof(T)) == true)
                {
                    Type abstraction = Operations.GetAbstraction(interfaces);

                    string name = abstraction.FullName;
                    Type target = Operations.Repository[name];
                    operations[name] = (IOperations)Activator.CreateInstance(target);
                }
            }

            return operations;
        }

        private static Type GetAbstraction(IEnumerable<Type> types)
        {
            return types.OrderByDescending(item => item.GetInterfaces().Length).FirstOrDefault();
        }
        #endregion
    }
}
