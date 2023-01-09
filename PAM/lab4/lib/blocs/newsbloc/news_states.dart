import 'package:lab4/models/article_model.dart';
import 'package:equatable/equatable.dart';
import 'package:lab4/models/featured_model.dart';

// Equatable for the NewsStates to not make duplicate calls and not rebuild the widget if the same state occurs.
class NewsStates extends Equatable {
  const NewsStates();

  // Props is a getter of equatable
  @override
  List<Object> get props => [];
}

class NewsInitState extends NewsStates {}

class NewsLoadingState extends NewsStates {}

class NewsLoadedState extends NewsStates {
  final List<ArticleModel> articleList;
  final List<FeaturedModel> featuredList;
  const NewsLoadedState({required this.articleList, required this.featuredList});
}

class NewsErrorState extends NewsStates {
  final String errorMessage;
  const NewsErrorState({required this.errorMessage});
}
