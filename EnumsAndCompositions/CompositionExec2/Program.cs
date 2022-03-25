using CompositionExec2.Entities;

/* Exercice output
------------------------------------------------------
Traveling to New Zealand
12 Likes - 25/03/2022 12:03:18
I'm going to visit this wonderful country!
Comments:
Have a nice trip!
Wow tha's awesome!
------------------------------------------------------

------------------------------------------------------
Good night guys
5 Likes - 25/03/2022 12:03:18
See you tomorrow
Comments:
Good night
May the force be with you
------------------------------------------------------
*/

var post01 = new Post("Traveling to New Zealand", "I'm going to visit this wonderful country!");
for (var i = 1; i <= 12; i++)
    post01.AddLike();
post01.AddComment(new Comment("Have a nice trip!"));
post01.AddComment(new Comment("Wow tha's awesome!"));

var post02 = new Post("Good night guys", "See you tomorrow");
for (var i = 1; i <= 5; i++)
    post02.AddLike();
post02.AddComment(new Comment("Good night"));
post02.AddComment(new Comment("May the force be with you"));

Console.Write(post01);
Console.WriteLine("");
Console.Write(post02);


