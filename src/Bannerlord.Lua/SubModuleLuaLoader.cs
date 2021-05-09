using Bannerlord.BUTR.Shared.Helpers;
using Bannerlord.ButterLib.SubModuleWrappers;

using System.IO;

namespace Bannerlord.Lua
{
    // Ideally, we should use BUTRLoader to make Lua SubModules
    // first class citizens, plus add support for SubModuleLua XML tag
    // instead of doing hardcoding.
    //
    //
    // Basically, there should be this hierarchy:
    //
    // * BUTRLoader exposes an interface to add support of Lua SubModules with the
    // custom SubModuleLua XML tag that adds them like the C# SubModules to the game
    //
    // * Bannerlord.Lua distributes MoonSharp and implements the interface for BUTRLoader to use
    //
    // * Bannerlord.LuaExample exposes the SubModules.xml and the %LUA% folder
    // and Bannerlord.Lua manages the mod via the BUTRLoader interface
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