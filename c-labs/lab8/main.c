#include "include/config.h"

int main() {
    /* -------------Demonstrative Counting Sort.---------------- */
    puts("COUNTING SORT ALG\nDemonstrative sort[ascending order]:");
    int *arr_test1 = arr_get_random_el(10);
    printf("[input arr]: \t");
    arr_print(arr_test1, 10);
    ascending_counting_sort(arr_test1, 10);
    printf("[output arr]:\t");
    arr_print(arr_test1, 10);
    puts("");

    puts("Demonstrative sort[descending order]:");
    printf("[input arr]: \t");
    arr_print(arr_test1, 10);
    descending_counting_sort(arr_test1, 10);
    printf("[output arr]:\t");
    arr_print(arr_test1, 10);
    puts("");

    /* -------------Demonstrative Bubble Sort.---------------- */
    puts("BUBBLE SORT ALG\nDemonstrative sort[ascending order]:");
    arr_test1 = arr_get_random_el(10);
    printf("[input arr]: \t");
    arr_print(arr_test1, 10);
    ascending_bubble_sort(arr_test1, 10);
    printf("[output arr]:\t");
    arr_print(arr_test1, 10);
    puts("");

    puts("Demonstrative sort[descending order]:");
    printf("[input arr]: \t");
    arr_print(arr_test1, 10);
    descending_bubble_sort(arr_test1, 10);
    printf("[output arr]:\t");
    arr_print(arr_test1, 10);
    puts("");

    free(arr_test1);

    /* -----------------------Tests.-------------------------- */
    puts("CS-Test sort ascending order:");
    test_ascending_c_s();
    puts("\n\nCS-Test sort descending order:");
    test_descending_c_s();

    puts("\n\nBS-Test sort ascending order:");
    test_ascending_b_s();
    puts("\n\nBS-Test sort descending order:");
    test_descending_b_s();
    puts("");
    return 0;
}

