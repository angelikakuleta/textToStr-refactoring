# Refactoring to Design Patterns

Refactoring changes the design without changing observable behaviour.

Redesign changes the design while observable behaviour may change. It can be performed in a series of small, focused and well-managed refactorings.

## Strategy pattern

A strategy is an object, which exposes one function. It can be an abstract class or an interface. Concrete strategies can vary, but they must all implement the base. In that way, consumer of a strategy doesn't have to be bound to any concrete implementation.

## Null Object pattern

Null object is a proper object, which implements whatever interface is expected from it but which behaves like it's not there. 
Can be applied to implement an optional processing step. When a processing needs to be done, it silently does nothing. It helps remove special cases and conditional logic.

## Composite pattern

Wraps a linear structure of objects of the same kind into a single object which exposes the same interface. Requires a composition function which maps one call to many calls of the same kind.

## Decorator pattern

One object wraps another object with the same interface. Intercepts calls to methods and adds own behavior.

## Builder pattern

Encapsulates the process of building a complex object. Consumer only declare intentions about the final product. Builder ensures that the product satisfies intentions. The whole process ends in calling the `Build` method.

`Build` method should not have any arguments. The builder object is supposed to accumulate content through its lifetime and then to use that content when `Build` method is invoked.

