using Microsoft.Practices.Unity;
using NavigatorDemo.Application;
using NavigatorDemo.Interfaces;
using NavigatorDemo.Model;
using NavigatorDemo.Repositories;

namespace NavigatorDemo.Application
{
    public static class UnityMapping
    {
        public static void RegisterElements(IUnityContainer container)
        {
            container.RegisterType<IInputOutput, FileIO>(new HierarchicalLifetimeManager());
            container.RegisterType<IMissionRepository, MissionRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IDroneRepository, DroneRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IRegionRepository, RegionRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISignalSender, NonSimultaneousSignalSender>(new HierarchicalLifetimeManager());            
            container.RegisterType<IGameInitializer, GameInitializer>(new InjectionConstructor(typeof(IRegionRepository),
                typeof(IDroneRepository), typeof(IMissionRepository), typeof(ISignalSender)));
        }    
    }
}
