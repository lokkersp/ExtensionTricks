# ExtensionTricks
some scary tricks with extension methods with &amp; without regular expressions match

## Magic [here](https://github.com/lokkersp/ExtensionTricks/blob/master/ExtensionTricks/Program.cs)

Разберем для лучшего понимания абстрактный метод расширения
```c#
        public static T[] CopyFirstN<T>(this T[] s,int n)
        {
            var rst = new T[n];
            for(int i = 0; i < n;i++)
            {
                rst[i] = s[i];
            }
            return rst;
        }
```
Мы говорим, что у нас есть некоторый статический метод для типа `T`, который может применяться только для массива типа `T`, и с аргументом `int n` и возвращающий массив того же типа.
``` c#
public static T[] CopyFirstN<T>(this T[] s,int n) { 
 //code was here
}
```
Задание конкретного типа для которого определяется метод расширения через:
```c# 
MyMethodName(this Type type)
```
Cоответственно можно использовать все что угодно, например все коллекции имеющие интерфейс `IList`.

```c#
public static string printList<T>(this IList<T> list)
```

Информация о паттернах методов расширения:

[Extension Methods Patterns Video](https://www.youtube.com/watch?v=YvRm-0jrN8c)

[Article in blog](https://nesteruk.wordpress.com/2010/03/22/extension-method-patterns/)

Немного о монадах в тему методов расширения:

[Maybe monad in C#](https://www.youtube.com/watch?v=-bMPUBPwtSg)

[Chained null checks and the maybe monad](http://devtalk.net/2010/09/12/chained-null-checks-and-the-maybe-monad/)
