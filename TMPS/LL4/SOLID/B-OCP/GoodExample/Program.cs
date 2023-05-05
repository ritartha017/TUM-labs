using GoodExample;
using GoodExample.Abstract;
using GoodExample.Concrete;

MealBase[] menu = new MealBase[] { new PotatoMeal(), new SaladMeal() };

Cook bob = new ("Bob");
bob.MakeDinner(menu);