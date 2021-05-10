SubModule = {}
SubModule.__index = SubModule

function SubModule:OnSubModuleLoad()
    base:SubModuleLoad();

end

function SubModule:OnSubModuleUnloaded()
    base:SubModuleUnloaded();

end

function SubModule:OnBeforeInitialModuleScreenSetAsRoot()
    base:BeforeInitialModuleScreenSetAsRoot();

end