# STensor

SIMD-Accelerated Tensors.

### What is SIMD?
Single Instruction, Multiple Data (SIMD) units refer to hardware components that perform the same operation on multiple data operands concurrently.
The concurrency is performed on a single thread, while utilizing the full size of the processor register to perform several operations at one.  
This approach could be combined with standard multithreading for massive performence boosts in numeric computations.

## Goals And Purpose
* Generic Tensor class with support for most numeric types
* Significant performence boost for mathematical computations compared to standard implementation
* Functional approach with immutable classes
* Easy to use and intuitive API

## Limitations
* Benefitial only for hardware which supports SIMD instructions
* Could perform worse than simple for loop approach, for very small tensors
* Supports only **Primitive Numeric Types** as ```Tensor``` elements. Supported types are:
  * ```byte, sbyte```
  * ```short, ushort```
  * ```int, uint```
  * ```long, ulong```
  * ```float```
  * ```double```

## License
This project is licensed under MIT license. For more info see the [License File](LICENSE)
