cmake_minimum_required(VERSION 3.17)
project(LAB4_LION)

set(CMAKE_C_STANDARD 11)

set(SOURCES main.c singly-linked-list.c anal-sys-f.c menus.c)
set(HEADERS singly-linked-list.h)

if(SOURCES)
    add_executable(LAB4_LION ${SOURCES} ${HEADERS})
else()
    message("The SOURCES was not defined!")
endif()