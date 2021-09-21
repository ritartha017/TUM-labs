//
// Created by _ritarda_ on 05-May-21.
//

#ifndef LAB8_UTILITIES_H
#define LAB8_UTILITIES_H

struct Resources{
    int memory;
    int comparisons;
    int swaps;
}s_resources_counting, s_resources_bubble;

int * arr_get_random_el(int el_count);

void ascending_counting_sort(int * arr, int el_count);
void descending_counting_sort(int * arr, int el_count);
void test_ascending_c_s();
void test_descending_c_s();

void ascending_bubble_sort(int * arr, int el_count);
void descending_bubble_sort(int * arr, int el_count);
void test_ascending_b_s();
void test_descending_b_s();

void arr_print(int * arr, int el_count);

#endif //LAB8_UTILITIES_H
