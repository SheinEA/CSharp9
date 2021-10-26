#nullable enable

var (first, second) = ((1, 2, 3), (4, 5, 6));

Expression<Func<(int x, int y, int z), (int a, int b, int c), int>> a = 
(f, s) => f.x + f.y + f.z + s.a + s.b + s.c;

WriteLine($"{a}");
WriteLine($"{a.Compile()(first, second)}");

a = (_, s) => s.a + s.b + s.c;

WriteLine($"{a}");
WriteLine($"{a.Compile()(first, second)}");

a = (_, _) => 0;

WriteLine($"{a}");
WriteLine($"{a.Compile()(first, second)}");

a = (f, _) => Unwrap(first);

static int Unwrap ((int, int, int) first){
    var (res, _, _) = first;
    return res;
}

WriteLine($"{a}");
WriteLine($"{a.Compile()(first, second)}");
