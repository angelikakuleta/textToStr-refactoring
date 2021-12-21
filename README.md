## Strategy pattern

A strategy is an object, which exposes one function. It can be an abstract class or an interface. Concrete strategies can vary, but they must all implement the base. In that way, consumer of a strategy doesn't have to be bound to any concrete implementation.

## Null Object pattern

Null object is a proper object, which implements whatever interface is expected from it but which behaves like it's not there. 
Can be applied to implement an optional processing step. When a processing needs to be done, it silently does nothing. It helps remove special cases and conditional logic.