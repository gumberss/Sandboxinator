import 'dart:convert';
import 'package:flutter/foundation.dart';
import 'package:http/http.dart';
import 'package:secondapi/models/transaction.dart';
import '../webclient.dart';

class TransactionWebClient {
  Future<List<Transaction>> findAll() async {
    final response = await client.get(baseUri);
    //final response = await get(Uri.http("172.21.144.1:8080", "/transactions"));
    final List<dynamic> decodedJson = jsonDecode(response.body);
    final List<Transaction> transactions =
        decodedJson.map((e) => Transaction.fromJson(e)).toList();
    return transactions;
  }

  Future<Transaction> save(Transaction transaction, String password) async {
    final response = await client.post(baseUri,
        headers: {
          'Content-type': 'application/json',
          'password': password,
        },
        body: jsonEncode(transaction.toJson()));

    _throwHttpError(response);

    Map<String, dynamic> jsonResponse = jsonDecode(response.body);

    final Transaction transactionResponse = Transaction.fromJson(jsonResponse);

    return transactionResponse;
  }

  void _throwHttpError(Response response) {
    if (_statusCoodeResponses.containsKey(response.statusCode)) {
      var message = _statusCoodeResponses[response.statusCode]!;

      if (message is Function) {
        throw HttpException(message(response));
      } else {
        throw HttpException(message);
      }
    }
  }

  static final Map<int, dynamic> _statusCoodeResponses = {
    400: 'There was an error submitting the transaction',
    401: 'Authentication Failed',
    409: (response) => response.body,
    500: 'Oh no! Server is crying :('
  };
}

class HttpException implements Exception {
  final String message;

  HttpException(this.message);
}
