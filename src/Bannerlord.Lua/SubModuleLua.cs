using Bannerlord.BUTR.Shared.Helpers;
using Bannerlord.Lua.Utils;

using MoonSharp.Interpreter;

using System.IO;

using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace Bannerlord.Lua
{
    internal class SubModuleLua : MBSubModuleBase
    {
        static SubModuleLua()
        {
            UserData.RegisterType<EmptySubModule>();
        }

        private readonly Script _subModuleScript;
        private readonly Table? _subModule;

        public SubModuleLua()
        {
            _subModuleScript = new Script();
            _subModuleScript.Globals["base"] = new EmptySubModule();

            if (ModuleInfoHelper.GetModuleByType(typeof(SubModuleLua)) is { } moduleInfo)
            {
                var subModuleFilePath = Path.Combine(moduleInfo.Folder, "Lua", "SubModule.lua");
                if (File.Exists(subModuleFilePath))
                {
                    _subModuleScript.DoString(File.ReadAllText(subModuleFilePath));
                }

                _subModule = _subModuleScript.Globals?["SubModule"] as Table;
            }
        }

        internal SubModuleLua(string moduleFolder, string scriptName, string subModuleClassType)
        {
            _subModuleScript = new Script();
            _subModuleScript.Globals["base"] = new EmptySubModule();

            var subModuleFilePath = Path.Combine(moduleFolder, "Lua", scriptName);
            if (File.Exists(subModuleFilePath))
            {
                _subModuleScript.DoString(File.ReadAllText(subModuleFilePath));
            }

            _subModule = _subModuleScript.Globals?[subModuleClassType] as Table;
        }

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            if (_subModule?["OnSubModuleLoad"] is Closure closure)
            {
                closure.Call();
            }
        }

        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();

            if (_subModule?["OnSubModuleUnloaded"] is Closure closure)
            {
                closure.Call();
            }
        }

        protected override void OnApplicationTick(float dt)
        {
            base.OnApplicationTick(dt);

            if (_subModule?["OnApplicationTick"] is Closure closure)
            {
                closure.Call(dt);
            }
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();

            if (_subModule?["OnBeforeInitialModuleScreenSetAsRoot"] is Closure closure)
            {
                closure.Call();
            }
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);

            if (_subModule?["OnGameStart"] is Closure closure)
            {
                closure.Call(game, gameStarterObject);
            }
        }


        public void OnServiceRegistration()
        {
            if (_subModule?["OnServiceRegistration"] is Closure closure)
            {
                closure.Call();
            }
        }


        public override bool DoLoading(Game game)
        {
            if (!base.DoLoading(game))
                return false;

            if (_subModule?["DoLoading"] is Closure closure && closure.Call(game) is { Type: DataType.Boolean } dynValue)
            {
                return dynValue.Boolean;
            }

            return false;
        }

        public override void OnGameLoaded(Game game, object initializerObject)
        {
            base.OnGameLoaded(game, initializerObject);

            if (_subModule?["OnGameLoaded"] is Closure closure)
            {
                closure.Call(game, initializerObject);
            }
        }

        public override void OnCampaignStart(Game game, object starterObject)
        {
            base.OnCampaignStart(game, starterObject);

            if (_subModule?["OnCampaignStart"] is Closure closure)
            {
                closure.Call(game, starterObject);
            }
        }

        public override void BeginGameStart(Game game)
        {
            base.BeginGameStart(game);

            if (_subModule?["BeginGameStart"] is Closure closure)
            {
                closure.Call(game);
            }
        }

        public override void OnGameEnd(Game game)
        {
            base.OnGameEnd(game);

            if (_subModule?["OnGameEnd"] is Closure closure)
            {
                closure.Call(game);
            }
        }

        public override void OnGameInitializationFinished(Game game)
        {
            base.OnGameInitializationFinished(game);

            if (_subModule?["OnGameInitializationFinished"] is Closure closure)
            {
                closure.Call(game);
            }
        }

        public override void OnMissionBehaviourInitialize(Mission mission)
        {
            base.OnMissionBehaviourInitialize(mission);

            if (_subModule?["OnMissionBehaviourInitialize"] is Closure closure)
            {
                closure.Call(mission);
            }
        }

        public override void OnMultiplayerGameStart(Game game, object starterObject)
        {
            base.OnMultiplayerGameStart(game, starterObject);

            if (_subModule?["OnMultiplayerGameStart"] is Closure closure)
            {
                closure.Call(game, starterObject);
            }
        }

        public override void OnNewGameCreated(Game game, object initializerObject)
        {
            base.OnNewGameCreated(game, initializerObject);

            if (_subModule?["OnNewGameCreated"] is Closure closure)
            {
                closure.Call(game, initializerObject);
            }
        }

        public override void OnConfigChanged()
        {
            base.OnConfigChanged();

            if (_subModule?["OnConfigChanged"] is Closure closure)
            {
                closure.Call();
            }
        }
    }
}