cmake_minimum_required(VERSION 3.17)
project(bst C)

set(CMAKE_C_STANDARD 11)

add_executable(bst main.c bst.c config.h)