using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefresherCourse
{
    internal interface IServiceA { void Execute(); }
    public class TypeAService1:IServiceA { public void Execute() => Console.WriteLine("TypeAService1.Execute()"); }

    class ServiceAClient
    {
        IServiceA _service;

        public ServiceAClient(IServiceA service) { _service = service; }
        public void Start()
            {
            Console.WriteLine("ServiceAClient.Start() called");
            _service.Execute();
        }
        }
    static class GenericServiceInjector
    {
        static Dictionary<object, object> _serviceContainer = new Dictionary<object, object>();
        public static void Add<T, U>() where U:new()
        {
            if (!_serviceContainer.ContainsKey(typeof(T))) { _serviceContainer.Add(typeof(T),new U()); }
        }
        public static TInterface GetService<TInterface>()
        {
            try
            {
                var t = (TInterface)_serviceContainer[typeof(TInterface)];
                return t;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception");
            }
        }
    }
    internal class DIP
    {
        internal static void Test()
        {
           // IServiceA service = new TypeAService1();
           GenericServiceInjector.Add<IServiceA,TypeAService1>();
            var service=GenericServiceInjector.GetService<IServiceA>();
            ServiceAClient client = new ServiceAClient(service);
            client.Start();
        }
    }
}
