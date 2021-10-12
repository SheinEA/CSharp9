#nullable enable

int?[] scores = {1, default, 2, 3};

WriteLine($"scores[1] is null {scores[1] is null}");
Assign();
WriteLine($"scores[1] is {scores[1]}");

void Assign(){
    ref var score = ref scores[1];
    score ??= 5; // as same: score = score ?? 5
    _ = score ?? throw new InvalidOperationException(nameof(Assign));
    score ??= 7;
}