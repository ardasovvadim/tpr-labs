// Math.cpp : Implementation of CMath

#include "pch.h"
#include "Math.h"


// CMath



STDMETHODIMP CMath::Add(LONG a, LONG b, LONG* c)
{
    *c = a + b;
    return S_OK;
}


STDMETHODIMP CMath::Substract(LONG a, LONG b, LONG* c)
{
    *c = a - b;
    return S_OK;
}


STDMETHODIMP CMath::Multiply(LONG a, LONG b, LONG* c)
{
    *c = a * b;
    return S_OK;
}


STDMETHODIMP CMath::Divide(LONG a, LONG b, LONG* c)
{
    *c = a / b;
    return S_OK;
}
