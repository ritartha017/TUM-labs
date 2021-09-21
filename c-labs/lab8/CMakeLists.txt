cmake_minimum_required(VERSION 3.19)
project(lab8 C)

set(CMAKE_C_STANDARD 11)

add_executable(lab8 main.c src/test_counting_sort.c include/config.h include/utilities.h src/utilities.c src/test_bubble_sort.c)