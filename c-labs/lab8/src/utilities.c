//
// Created by _ritarda_ on 05-May-21.
//

#include "../include/config.h"
/**
 * Print out a 1-D @arr with @el_count size.
 */
void arr_print(int arr[], int el_count ) {
    for (int i = 0; i < el_count ; ++i) {
        printf("%d ", arr[i]);
    }
    printf("\n");
}

/**
 * Fills and @return a 1-D array with @el_count random numbers.
 */
int* arr_get_random_el(int el_count){
    int *new_arr = (int *)malloc(sizeof(int) * el_count);
    srand(time(0));
    for (int i = 0; i < el_count; ++i) {
        new_arr[i] = rand();
    }
    return new_arr;
}

