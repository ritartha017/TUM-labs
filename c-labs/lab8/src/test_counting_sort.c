//
// Created by _ritarda_ on 05-May-21.
//
#include "../include/config.h"

/**
 * Sort an array in ascending order using counting sort.
 * @param arr: input list of integers to sort
 * @param el_count: input list size
 */
void ascending_counting_sort(int *arr, int el_count) {
    s_resources_counting.memory = 0;
    s_resources_counting.swaps = 0;
    s_resources_counting.comparisons = 0;
    int *output = (int *)malloc(sizeof(int) * el_count);
    s_resources_counting.memory += el_count;

    /* Find the largest element of the array. */
    int max = arr[0];
    for (int i = 1; i < el_count; ++i) {
        ++s_resources_counting.comparisons;
        if (arr[i] > max) max = arr[i];
    }

    /* The size of count must be at least (max+1). */
    int * count = (int *)malloc(sizeof(int) * (max+1));
    s_resources_counting.memory += (max+1);

    /* Initialize count array with all zeros. */
    for (int i = 0; i <= max; ++i) {
        count[i] = 0;
    }
    /* Store the count of each element. */
    for (int i = 0; i < el_count; ++i) {
        ++count[arr[i]];
    }
    /* Store the cumulative count of each array. */
    for (int i = 1; i <= max; ++i) {
        count[i] += count[i - 1];
    }
    /* Find the index of each element of the original array in count array,
    and place the elements in output array. */
    for (int i = el_count - 1; i >= 0; --i) {
        output[count[arr[i]] - 1] = arr[i];
        --count[arr[i]];
    }
    /* Copy the sorted elements into original array. */
    for (int i = 0; i < el_count; ++i) {
        arr[i] = output[i];
    }
    free(output); free(count);
}

/**
 * Sort an array in descending order using counting sort.
 * @param arr: input list of integers to sort
 * @param el_count: input list size
 */
void descending_counting_sort(int *arr, int el_count) {
    s_resources_counting.memory = 0;
    s_resources_counting.swaps = 0;
    s_resources_counting.comparisons = 0;

    int *output = (int *)malloc(sizeof(int) * el_count);
    s_resources_counting.memory += el_count;

    int max = arr[0];
    for (int i = 1; i < el_count; ++i) {
        s_resources_counting.comparisons++;
        if (arr[i] > max) max = arr[i];
    }

    int * count = (int *)malloc(sizeof(int) * (max+1));
    s_resources_counting.memory += (max+1);

    for (int i = 0; i <= max; ++i) {
        count[i] = 0;
    }
    for (int i = 0; i < el_count; ++i) {
        ++count[arr[i]];
    }
    for (int i = 1; i <= max; ++i) {
        count[i] += count[i - 1];
    }
    for (int i = el_count - 1; i >= 0; --i) {
        output[count[arr[i]] - 1] = arr[i];
        --count[arr[i]];
    }
    for (int i = 0; i < el_count; ++i) {
        arr[el_count - i - 1] = output[i];
    }
    free(output);
    free(count);
}

/**
 * Test ascending_counting_sort procedure.
 */
void test_ascending_c_s(){
    FILE *f = fopen("../vectors_time/counting_sort.txt", "w");
    struct timeval stop, start;
    int REPETITIONS = 7;
    int iter = 0;
    int el_count = 10;
    /* Arrays to store the time of each iteration. */
    long int c1[REPETITIONS], c2[REPETITIONS], c3[REPETITIONS];

    printf("Size\t\t(microseconds)\tRandom Case Best Case   Worst Case Swaps Compar.  Memory\n"
           "(elements)\t   (10^-6)\t\t\t\t\t   (num)  (num)\t  (B)");
    while (iter++ < REPETITIONS){
        int *arr_rand       = arr_get_random_el(el_count);
        int *arr_sorted     = (int *)malloc(sizeof(int) * el_count);
        int *arr_rev_sorted = (int *)malloc(sizeof(int) * el_count);

        for (int i = 0; i < el_count; ++i) {
            arr_sorted[i] = i;
            arr_rev_sorted[i] = el_count - i - 1;
        }
        gettimeofday(&start, NULL);
        ascending_counting_sort(arr_rand, el_count);
        gettimeofday(&stop, NULL);
        c1[iter] = (stop.tv_usec - start.tv_usec);

        gettimeofday(&start, NULL);
        ascending_counting_sort(arr_sorted, el_count);
        gettimeofday(&stop, NULL);
        c2[iter] = (stop.tv_usec - start.tv_usec);

        gettimeofday(&start, NULL);
        ascending_counting_sort(arr_rev_sorted, el_count);
        gettimeofday(&stop, NULL);
        c3[iter] = (stop.tv_usec - start.tv_usec);

        printf("\n%-16d Time taken->\t%010lu  %010lu  %010lu%4d\t %07d  %08d",
               el_count,
               c1[iter],
               c2[iter],
               c3[iter],
               s_resources_counting.swaps,
               s_resources_counting.comparisons,
               s_resources_counting.memory);
        fprintf(f, "%d, %lu, %lu, %lu, %d, %d, %d\n",
               el_count,
               c1[iter],
               c2[iter],
               c3[iter],
               s_resources_counting.swaps,
               s_resources_counting.comparisons,
               s_resources_counting.memory);
        free(arr_rand); arr_rand = NULL;
        free(arr_sorted); arr_sorted = NULL;
        free(arr_rev_sorted); arr_rev_sorted = NULL;
        el_count = el_count * 10;
    }
    fclose(f);
}

/**
 * Test descending_counting_sort procedure.
 */
void test_descending_c_s(){
    struct timeval stop, start;
    int REPETITIONS = 7;
    int iter = 0;
    int el_count = 10;
    long int c1[REPETITIONS], c2[REPETITIONS], c3[REPETITIONS];

    printf("Size\t\t(microseconds)\tRandom Case Best Case   Worst Case Swaps Compar.  Memory\n"
           "(elements)\t   (10^-6)\t\t\t\t\t   (num)  (num)\t  (B)");
    while (iter++ < REPETITIONS){
        int *arr_rand       = arr_get_random_el(el_count);
        int *arr_sorted     = (int *)malloc(sizeof(int) * el_count);
        int *arr_rev_sorted = (int *)malloc(sizeof(int) * el_count);

        for (int i = 0; i < el_count; ++i) {
            arr_sorted[i] = i;
            arr_rev_sorted[i] = el_count - i - 1;
        }
        gettimeofday(&start, NULL);
        descending_counting_sort(arr_rand, el_count);
        gettimeofday(&stop, NULL);
        c1[iter] = (stop.tv_usec - start.tv_usec);

        gettimeofday(&start, NULL);
        descending_counting_sort(arr_sorted, el_count);
        gettimeofday(&stop, NULL);
        c2[iter] = (stop.tv_usec - start.tv_usec);

        gettimeofday(&start, NULL);
        descending_counting_sort(arr_rev_sorted, el_count);
        gettimeofday(&stop, NULL);
        c3[iter] = (stop.tv_usec - start.tv_usec);

        printf("\n%-16d Time taken->\t%010lu  %010lu  %010lu%4d\t %07d  %08d",
               el_count,
               c1[iter],
               c2[iter],
               c3[iter],
               s_resources_counting.swaps,
               s_resources_counting.comparisons,
               s_resources_counting.memory);
        free(arr_rand); arr_rand = NULL;
        free(arr_sorted); arr_sorted = NULL;
        free(arr_rev_sorted); arr_rev_sorted = NULL;
        el_count = el_count * 10;
    }
}
