﻿#pragma once

#pragma warning(disable: 4530) // disable exception warning

#include <cstdint>
//#include <stdint.h>
#include <cassert>
//#include <assert.h>
#include <typeinfo>

#if defined(_WIN64)
#include <DirectXMath.h>
#endif

// common headers
#include "../Utilities/Utilities.h"
#include "../Utilities/MathTypes.h"
#include "PrimitiveTypes.h"