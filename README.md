# Refactoring to Design Patterns

Refactoring changes the design without changing observable behaviour.

Redesign changes the design while observable behaviour may change. It can be performed in a series of small, focused and well-managed refactorings.

## *Circular dependencies

Avoid referencing types that are defined deeper than the level of your own type.

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

## *Inversion of Control principle

Consumer of a feature is the one who defines the public interface of that feature. Any concrete impelmentation would  depend on the consumer. The concrete implementation can then be replaced without affecting the consumer. Concrete implementation of abstract interface must be injected into the consumer at run time. That is where [Dependency Injection](#dependency-injection-pattern) comes to the picture.

## Dependency Injection pattern

Using DI, we move the creation and binding of the dependent objects outside of the class that depends on them. Dependencies are injected into the consumer by another entity which is controlling the construction of the application's object graph at run time.

## Rules pattern
It helps to encapsulate each business rule in a separate object and decouple the definition of business rules from their processing logic (applying the [Single Responsibility principle]()). New rules can be added without the need to modify the rest of the application logic.
