string[] input = Console.ReadLine().Split();
int n = int.Parse(input[0]);
int m = int.Parse(input[1]);

string[] arr = new string[n];

for (int i = 0; i < n; i++) {
    arr[i] = Console.ReadLine();
}


// 예를들어 11, 12 라면
// 0 ~7, 1 ~ 8, 2 ~ 9, 3 ~ 10, 4 ~ 11
// 0 ~ 7, 1 ~ 8, 2 ~ 9, 3 ~ 10, 4 ~ 11, 5 ~ 12


int minValue = 64;

for (int i = 0; i < n-7; i++) { // 0 1 2 3
    for (int j = 0; j < m-7; j++) { // 0 1 2 3 4
        int wrongCount = findChess(i, j);
        minValue = Math.Min(minValue, wrongCount);
        minValue = Math.Min(minValue, 64 - wrongCount);
    }
}
Console.WriteLine(minValue);

// BBBBBBBBBB
// 0123456789

int findChess(int n, int m) { // 0 4
    // Console.WriteLine("--------------------------");
    // Console.WriteLine(n + " " + m);

    char B = 'B';
    char W = 'W';
    char lastWord = B; // 최대 64
    // 반대의 경우 64 - w
    int wrongCount = 0;

    for (int j = n; j < n+8; j++) { // 4 ~ 11
        string row = arr[j].Substring(m, 8); // 0 ~ 7
        char[] rowArray = row.ToCharArray();
        for (int k = 0; k < 8; k++) {
            // Console.Write(rowArray[k]);

            if (rowArray[k] != lastWord) {
                wrongCount++;
            }

            if (k != 7)
            lastWord = lastWord == B ? W : B; // 반복문마다 마지막 단어 바꿔주기.

        }

    }
    // Console.WriteLine("--------------------------");
    // Console.WriteLine("wrongCount : " + wrongCount);

    return wrongCount;
}






