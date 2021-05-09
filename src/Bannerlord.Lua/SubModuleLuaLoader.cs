using Bannerlord.BUTR.Shared.Helpers;
using Bannerlord.ButterLib.SubModuleWrappers;

using System.IO;

namespace Bannerlord.Lua
{
    public class SubModuleLuaLoader : MBSubModuleBaseListWrapper
    {
        public SubModuleLuaLoader()
        {
            foreach (var moduleInfo in ModuleInfoHelper.GetLoadedModules())
            {
                if (Directory.Exists(Path.Combine(moduleInfo.Folder, "Lua")))
                {
                    SubModules.Add(new MBSubModuleBaseWrapper(new SubModuleLua(moduleInfo)));
                }
            }
        }
    }
}