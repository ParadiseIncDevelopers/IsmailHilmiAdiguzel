// Example program
#include <stdio.h>

int main()
{
    for (int i = 2; i <= 50; i++)
    {
        while (i % 2 == 0)
        {
            printf("%d \n", i);
            i++;
        }
    }
    getch();
    return 0;
}
