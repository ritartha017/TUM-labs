#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <assert.h>

typedef struct Edge edge_t;
struct Edge {
    unsigned to;
    edge_t *next;
};

typedef struct Graph graph_t;
struct Graph {
    unsigned maxnode;
    struct {
        int color;
        edge_t *adjacency;
    }node_t;
};

graph_t * graph_test1(graph_t * graph);
graph_t * graph_test2(graph_t * graph);
graph_t * graph_test3(graph_t * graph);

void graph_print(graph_t * graph, int maxcol);
void graph_insert_edge(unsigned from, unsigned to, graph_t * graph);

bool try_color(unsigned node, int maxcol, graph_t * graph);
bool is_valid_color(unsigned node, int color, graph_t * graph);

int main(){
    graph_t * graph = NULL;
    graph = graph_test3(graph);

    for( int maxcol = 0; maxcol <= 4; maxcol++)
        if (!try_color(0, maxcol, graph))
            printf("Coloring using %u color(s) isn't possible.\n", maxcol);
        else {
            /*By the Four Color Theorem, every planar graph can be 4-colored.*/
            assert(maxcol <= 4);
            return 0;
        }

   return 0;
}

bool is_valid_color(unsigned node, int color, graph_t * graph){
    edge_t *edge = graph[node].node_t.adjacency;
    while(edge){
        if (graph[edge->to].node_t.color == color) return false;
        edge = edge->next;
    }
    return true;
}

bool try_color(unsigned node, int maxcol, graph_t * graph){
    if (node == graph->maxnode) { graph_print(graph, maxcol); return true; }

    for (int color = 1; color <= maxcol; ++color)
        if (is_valid_color(node, color, graph)) {
            graph[node].node_t.color = color;
            if (try_color(node + 1, maxcol, graph)) return true;
        }
    graph[node].node_t.color = 0;
    return false;
}

void graph_print(graph_t * graph, int maxcol){
    printf("Valid coloring with %d color(s):\n", maxcol);
    for (unsigned n = 0; n < graph->maxnode; ++n)
        printf("VERTEX (%u) => Color %u\n", n+1, graph[n].node_t.color);
}

void graph_insert_edge(unsigned from, unsigned to, graph_t * graph){
    edge_t *edge = (edge_t*)malloc(sizeof(edge_t));
    edge->to = to;
    edge->next = graph[from].node_t.adjacency;
    graph[from].node_t.adjacency = edge;
}

void graph_init(unsigned from, unsigned to, graph_t * graph);
void graph_init(unsigned from, unsigned to, graph_t * graph){
    graph_insert_edge(from-1, to-1, graph);
    graph_insert_edge(to-1, from-1, graph);
}

graph_t * graph_test1(graph_t * graph){
    unsigned maxnode = 10;
    /*(step1)Initializes allocated memory with zero(both the color and the pointer).*/
    graph = (graph_t*)calloc(maxnode, sizeof(graph_t));

    graph->maxnode = maxnode;
    graph_init(1, 2, graph);
    graph_init(1, 3, graph);
    graph_init(1, 7, graph);
    graph_init(1, 9, graph);
    graph_init(1, 10, graph);
    graph_init(2, 3, graph);
    graph_init(2, 4, graph);
    graph_init(3, 4, graph);
    graph_init(3, 5, graph);
    graph_init(3, 7, graph);
    graph_init(4, 5, graph);
    graph_init(5, 6, graph);
    graph_init(5, 7, graph);
    graph_init(6, 7, graph);
    graph_init(6, 8, graph);
    graph_init(7, 8, graph);
    graph_init(7, 9, graph);
    graph_init(8, 9, graph);
    graph_init(8, 10, graph);
    graph_init(9, 10, graph);
    return graph;
}

graph_t * graph_test2(graph_t * graph){
    unsigned maxnode = 8;
    /*(step1)Initializes allocated memory with zero(both the color and the pointer).*/
    graph = (graph_t*)calloc(maxnode, sizeof(graph_t));

    graph->maxnode = maxnode;
    graph_init(1, 4, graph);
    graph_init(1, 6, graph);
    graph_init(1, 8, graph);
    graph_init(2, 3, graph);
    graph_init(2, 5, graph);
    graph_init(2, 7, graph);
    graph_init(3, 6, graph);
    graph_init(3, 8, graph);
    graph_init(4, 5, graph);
    graph_init(4, 7, graph);
    graph_init(5, 8, graph);
    graph_init(6, 7, graph);
    return graph;
}

graph_t * graph_test3(graph_t * graph){
    unsigned maxnode = 11;
    /*(step1)Initializes allocated memory with zero(both the color and the pointer).*/
    graph = (graph_t*)calloc(maxnode, sizeof(graph_t));

    graph->maxnode = maxnode;
    graph_init(1, 2, graph);
    graph_init(1, 4, graph);
    graph_init(1, 9, graph);
    graph_init(1, 11, graph);
    graph_init(2, 3, graph);
    graph_init(2, 7, graph);
    graph_init(3, 5, graph);
    graph_init(3, 8, graph);
    graph_init(3, 9, graph);
    graph_init(4, 5, graph);
    graph_init(4, 7, graph);
    graph_init(5, 6, graph);
    graph_init(5, 11, graph);
    graph_init(6, 7, graph);
    graph_init(6, 9, graph);
    graph_init(7, 8, graph);
    graph_init(7, 10, graph);
    graph_init(8, 11, graph);
    graph_init(9, 10, graph);
    graph_init(10, 11, graph);
    return graph;
}
