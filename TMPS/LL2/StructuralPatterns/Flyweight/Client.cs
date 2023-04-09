using Flyweight.FlyweightFactory;

var lemonadesFactory = new LemonadeMaker();
var lemonade = lemonadesFactory.GetLemonade("lemon");
lemonade.Make("with no sugar", 2);
var lemonade2 = lemonadesFactory.GetLemonade("lemon");