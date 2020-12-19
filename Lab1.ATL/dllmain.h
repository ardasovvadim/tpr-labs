// dllmain.h : Declaration of module class.

class CLab1ATLModule : public ATL::CAtlDllModuleT< CLab1ATLModule >
{
public :
	DECLARE_LIBID(LIBID_Lab1ATLLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_LAB1ATL, "{7b7fb63a-b818-4feb-ab1c-58db886aa921}")
};

extern class CLab1ATLModule _AtlModule;
