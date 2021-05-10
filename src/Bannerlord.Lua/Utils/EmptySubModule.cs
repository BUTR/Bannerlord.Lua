using Bannerlord.ButterLib.SubModuleWrappers;

using TaleWorlds.MountAndBlade;

namespace Bannerlord.Lua.Utils
{
    internal class EmptySubModule : MBSubModuleBaseWrapper
    {
        private class EmptySubModuleImpl : MBSubModuleBase { }

        public EmptySubModule() : base(new EmptySubModuleImpl()) { }
        protected override void OnSubModuleLoad()
        {
            OnSubModuleLoad();
        }
    }
}