import 'dart:convert';
import 'package:flutter/services.dart';
import 'package:lab5/src/domain/models/article_model.dart';
import 'package:http/http.dart' as http;
import 'package:lab5/src/domain/models/featured_model.dart';

class NewsRepository {
  Future<String> getJson() => rootBundle.loadString('assets/news.json');

  Future<List<ArticleModel>> fetchNews() async {
    //var response = await http.get(Uri.parse(
    //     "https://newsapi.org/v2/top-headlines?country=us&apiKey=ab3b6086568c4c00ad6c843bf2aa2cf5"));
    //var data = jsonDecode(response.body);
    var data = json.decode(await getJson());
    List<ArticleModel> articleModelList = [];
    //if (response.statusCode == 200) {
      for (var item in data["news"]) {
        ArticleModel articleModel = ArticleModel.fromJson(item);
        articleModelList.add(articleModel);
      }
      return articleModelList;
    //} else return articleModelList; // empty list
  }

  Future<List<FeaturedModel>> fetchFeatured() async {
    var data = json.decode(await getJson());
    List<FeaturedModel> featureModelList = [];
    for (var item in data["featured"]) {
      FeaturedModel featureModel = FeaturedModel.fromJson(item);
      featureModelList.add(featureModel);
    }
    return featureModelList;
  }
}
