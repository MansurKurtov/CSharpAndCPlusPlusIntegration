#include "stdafx.h"
#include <iostream>

typedef struct _wfs_cim_note_type
{
	USHORT usNoteID;
	CHAR cCurrencyID[3];
	ULONG ulValues;
	USHORT usRelease;
	BOOL bConfigured;
} WFSCIMNOTETYPE, *LPWFSCIMNOTETYPE;

typedef struct _wfs_cim_note_type_list
{
	USHORT usNumOfNoteTypes;
} WFSCIMNOTETYPELIST;

extern "C" __declspec(dllexport) WFSCIMNOTETYPELIST* __stdcall getCurrencyList() {
	WFSCIMNOTETYPELIST list;
	list.usNumOfNoteTypes = 5;

	WFSCIMNOTETYPELIST* address = &list;
	std::cout << &list << std::endl;

	return address;
}
