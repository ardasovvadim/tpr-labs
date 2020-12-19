

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 8.01.0622 */
/* at Tue Jan 19 05:14:07 2038
 */
/* Compiler settings for Lab1ATL.idl:
    Oicf, W1, Zp8, env=Win32 (32b run), target_arch=X86 8.01.0622 
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */



/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 500
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif /* __RPCNDR_H_VERSION__ */

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __Lab1ATL_i_h__
#define __Lab1ATL_i_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IMath_FWD_DEFINED__
#define __IMath_FWD_DEFINED__
typedef interface IMath IMath;

#endif 	/* __IMath_FWD_DEFINED__ */


#ifndef __Math_FWD_DEFINED__
#define __Math_FWD_DEFINED__

#ifdef __cplusplus
typedef class Math Math;
#else
typedef struct Math Math;
#endif /* __cplusplus */

#endif 	/* __Math_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"
#include "shobjidl.h"

#ifdef __cplusplus
extern "C"{
#endif 


#ifndef __IMath_INTERFACE_DEFINED__
#define __IMath_INTERFACE_DEFINED__

/* interface IMath */
/* [unique][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IMath;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("bb8360f9-2583-4c0e-922b-ca0c4e391fe2")
    IMath : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Add( 
            /* [in] */ LONG a,
            /* [in] */ LONG b,
            /* [retval][out] */ LONG *c) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Substract( 
            /* [in] */ LONG a,
            /* [in] */ LONG b,
            /* [retval][out] */ LONG *c) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Multiply( 
            /* [in] */ LONG a,
            /* [in] */ LONG b,
            /* [retval][out] */ LONG *c) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Divide( 
            /* [in] */ LONG a,
            /* [in] */ LONG b,
            /* [retval][out] */ LONG *c) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IMathVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IMath * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IMath * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IMath * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IMath * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IMath * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IMath * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IMath * This,
            /* [annotation][in] */ 
            _In_  DISPID dispIdMember,
            /* [annotation][in] */ 
            _In_  REFIID riid,
            /* [annotation][in] */ 
            _In_  LCID lcid,
            /* [annotation][in] */ 
            _In_  WORD wFlags,
            /* [annotation][out][in] */ 
            _In_  DISPPARAMS *pDispParams,
            /* [annotation][out] */ 
            _Out_opt_  VARIANT *pVarResult,
            /* [annotation][out] */ 
            _Out_opt_  EXCEPINFO *pExcepInfo,
            /* [annotation][out] */ 
            _Out_opt_  UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Add )( 
            IMath * This,
            /* [in] */ LONG a,
            /* [in] */ LONG b,
            /* [retval][out] */ LONG *c);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Substract )( 
            IMath * This,
            /* [in] */ LONG a,
            /* [in] */ LONG b,
            /* [retval][out] */ LONG *c);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Multiply )( 
            IMath * This,
            /* [in] */ LONG a,
            /* [in] */ LONG b,
            /* [retval][out] */ LONG *c);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Divide )( 
            IMath * This,
            /* [in] */ LONG a,
            /* [in] */ LONG b,
            /* [retval][out] */ LONG *c);
        
        END_INTERFACE
    } IMathVtbl;

    interface IMath
    {
        CONST_VTBL struct IMathVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IMath_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IMath_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IMath_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IMath_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define IMath_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define IMath_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define IMath_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#define IMath_Add(This,a,b,c)	\
    ( (This)->lpVtbl -> Add(This,a,b,c) ) 

#define IMath_Substract(This,a,b,c)	\
    ( (This)->lpVtbl -> Substract(This,a,b,c) ) 

#define IMath_Multiply(This,a,b,c)	\
    ( (This)->lpVtbl -> Multiply(This,a,b,c) ) 

#define IMath_Divide(This,a,b,c)	\
    ( (This)->lpVtbl -> Divide(This,a,b,c) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IMath_INTERFACE_DEFINED__ */



#ifndef __Lab1ATLLib_LIBRARY_DEFINED__
#define __Lab1ATLLib_LIBRARY_DEFINED__

/* library Lab1ATLLib */
/* [version][uuid] */ 


EXTERN_C const IID LIBID_Lab1ATLLib;

EXTERN_C const CLSID CLSID_Math;

#ifdef __cplusplus

class DECLSPEC_UUID("b335b87a-cae8-4ccd-8fc0-8e37ebe2e04a")
Math;
#endif
#endif /* __Lab1ATLLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


