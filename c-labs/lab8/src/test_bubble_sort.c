//
// Created by _ritarda_ on 06-May-21.
//
#include "../include/config.h"

/**
 * Sort an array in ascending order using bubble sort.
 * @param arr: input list of integers to sort
 * @param el_count: input list size
 */
void ascending_bubble_sort(int *arr, int size) {
    s_resources_bubble.memory = 0;
    s_resources_bubble.swaps = 0;
    s_resources_bubble.comparisons = 0;
    /* loop to access each arr elems */
    for (int step = 0; step < size - 1; ++step)
        /* loop to compare arr elems */
        for (int i = 0; i < size - step - 1; ++i) {
            ++s_resources_bubble.comparisons;
            if (arr[i] > arr[i + 1]) {
                ++s_resources_bubble.swaps;
                /* swaps elements if they are not in the intended order */
                int temp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = temp;
            }
        }
}

/**
 * Sort an array in descending order using bubble sort.
 * @param arr: input list of integers to sort
 * @param el_count: input list size
 */
void descending_bubble_sort(int *arr, int size) {
    s_resources_bubble.memory = 0;
    s_resources_bubble.swaps = 0;
    s_resources_bubble.comparisons = 0;
    /* loop to access each arr elems */
    for (int step = 0; step < size - 1; ++step)
        /* loop to compare arr elems */
        for (int i = 0; i < size - step - 1; ++i) {
            ++s_resources_bubble.comparisons;
            if (arr[i] < arr[i + 1]) {
                ++s_resources_bubble.swaps;
                /* swaps elements if they are not in the intended order */
                int temp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = temp;
            }
        }
}

/**
 * Test ascending_bubble_sort procedure.
 */
void test_ascending_b_s(){
    FILE *f = fopen("../vectors_time/bubble_sort.txt", "w");
    struct timeval stop, start;
    int REPETITIONS = 5;
    int iter = 0;
    int el_count = 10;
    double c1[REPETITIONS], c2[REPETITIONS], c3[REPETITIONS];

    printf("Size\t\t\t     Random\tBest\t Worst\t   Swaps\tCompar.\t Memory\n"
           "(elements)\t (seconds)\t\t\t\t   (num)\t(num)\t (B)");
    while (iter++ < REPETITIONS){
        int *arr_rand       = arr_get_random_el(el_count);
        int *arr_sorted     = (int *)malloc(sizeof(int) * el_count);
        int *arr_rev_sorted = (int *)malloc(sizeof(int) * el_count);

        for (int i = 0; i < el_count; ++i) {
            arr_sorted[i] = i;
            arr_rev_sorted[i] = el_count - i - 1;
        }
        gettimeofday(&start, NULL);
        ascending_bubble_sort(arr_rand, el_count);
        gettimeofday(&stop, NULL);
        c1[iter] = ((double)(stop.tv_sec - start.tv_sec));

        gettimeofday(&start, NULL);
        ascending_bubble_sort(arr_sorted, el_count);
        gettimeofday(&stop, NULL);
        c2[iter] = ((double)(stop.tv_sec - start.tv_sec));

        gettimeofday(&start, NULL);
        ascending_bubble_sort(arr_rev_sorted, el_count);
        gettimeofday(&stop, NULL);
        c3[iter] = ((double)(stop.tv_sec - start.tv_sec));

        printf("\n%-16d Time taken->%05f  %05f  %05f  %010d %09d   %d",
               el_count,
               c1[iter],
               c2[iter],
               c3[iter],
               s_resources_bubble.swaps,
               s_resources_bubble.comparisons,
               s_resources_bubble.memory);
        fprintf(f, "%d, %lu, %lu, %lu, %d, %d, %d\n",
                el_count,
                (long int)c1[iter],
                (long int)c2[iter],
                (long int)c3[iter],
                s_resources_bubble.swaps,
                s_resources_bubble.comparisons,
                s_resources_bubble.memory);
        free(arr_rand); arr_rand = NULL;
        free(arr_sorted); arr_sorted = NULL;
        free(arr_rev_sorted); arr_rev_sorted = NULL;
        el_count = el_count * 10;
    }
    fclose(f);
}

/**
 * Test descending_bubble_sort procedure.
 */
void test_descending_b_s(){
    struct timeval stop, start;
    int REPETITIONS = 5;
    int iter = 0;
    int el_count = 10;
    double c1[REPETITIONS], c2[REPETITIONS], c3[REPETITIONS];

    printf("Size\t\t\t     Random\tBest\t Worst\t   Swaps\tCompar.\t Memory\n"
           "(elements)\t (seconds)\t\t\t\t   (num)\t(num)\t (B)");
    while (iter++ < REPETITIONS){
        int *arr_rand       = arr_get_random_el(el_count);
        int *arr_sorted     = (int *)malloc(sizeof(int) * el_count);
        int *arr_rev_sorted = (int *)malloc(sizeof(int) * el_count);

        for (int i = 0; i < el_count; ++i) {
            arr_sorted[i] = i;
            arr_rev_sorted[i] = el_count - i - 1;
        }
        gettimeofday(&start, NULL);
        descending_bubble_sort(arr_rand, el_count);
        gettimeofday(&stop, NULL);
        c1[iter] = ((double)(stop.tv_sec - start.tv_sec));

        gettimeofday(&start, NULL);
        descending_bubble_sort(arr_sorted, el_count);
        gettimeofday(&stop, NULL);
        c2[iter] = ((double)(stop.tv_sec - start.tv_sec));

        gettimeofday(&start, NULL);
        descending_bubble_sort(arr_rev_sorted, el_count);
        gettimeofday(&stop, NULL);
        c3[iter] = ((double)(stop.tv_sec - start.tv_sec));

        printf("\n%-16d Time taken->%05f  %05f  %05f  %010d %09d   %d",
               el_count,
               c1[iter],
               c2[iter],
               c3[iter],
               s_resources_bubble.swaps,
               s_resources_bubble.comparisons,
               s_resources_bubble.memory);
        free(arr_rand); arr_rand = NULL;
        free(arr_sorted); arr_sorted = NULL;
        free(arr_rev_sorted); arr_rev_sorted = NULL;
        el_count = el_count * 10;
    }
}