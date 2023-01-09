import 'dart:async';
import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

Future<Article> fetchArticle(int id) async {
  final response = await http
      .get(Uri.parse('https://news-app-api.k8s.devebs.net/articles/$id'));

  if (response.statusCode == 200) {
    // If the server did return a 200 OK response,
    // then parse the JSON.
    return Article.fromJson(jsonDecode(response.body));
  } else {
    // If the server did not return a 200 OK response,
    // then throw an exception.
    throw Exception('Failed to load article');
  }
}

class Article {
  final String content;
  final int id;
  final int views_count;
  final String title;

  const Article ({
    required this.content,
    required this.id,
    required this.views_count,
    required this.title
  });

  factory Article.fromJson(Map<String, dynamic> json) {
    return Article(
        content: json['content'],
        id: json['id'],
        views_count: json['views_count'],
        title: json['title']
    );
  }
}