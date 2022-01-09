import 'package:http/http.dart';
import 'package:http_interceptor/http_interceptor.dart';
import 'interceptors/logging_interceptor.dart';

Uri baseUri = Uri.http("192.168.15.6:8080", "/transactions");

final Client client = InterceptedClient.build(interceptors: [
  LoggingInterceptor(),
], requestTimeout: Duration(seconds: 5));
