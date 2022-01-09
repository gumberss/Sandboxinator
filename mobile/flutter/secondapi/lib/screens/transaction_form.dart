import 'dart:async';

import 'package:firebase_crashlytics/firebase_crashlytics.dart';
import 'package:flutter/material.dart';
//import 'package:giffy_dialog/giffy_dialog.dart';
import 'package:secondapi/components/progress.dart';
import 'package:secondapi/components/response_dialog.dart';
import 'package:secondapi/components/transaction_auth_dialog.dart';
import 'package:secondapi/http/webclients/transaction_webclient.dart';
import 'package:secondapi/models/contact.dart';
import 'package:secondapi/models/transaction.dart';
import 'package:uuid/uuid.dart';

class TransactionForm extends StatefulWidget {
  final Contact contact;

  TransactionForm(this.contact);

  @override
  _TransactionFormState createState() => _TransactionFormState();
}

class _TransactionFormState extends State<TransactionForm> {
  final TextEditingController _valueController = TextEditingController();
  final String transactionId = Uuid().v4();
  final TransactionWebClient _webClient = TransactionWebClient();
  bool _sending = false;
  final _scaffoldKey = GlobalKey<ScaffoldState>();

  @override
  Widget build(BuildContext context) {
    print('Transaction form id $transactionId');
    return Scaffold(
      key: _scaffoldKey,
      appBar: AppBar(
        title: Text('New transaction'),
      ),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: <Widget>[
              Visibility(
                child: Padding(
                  padding: EdgeInsets.all(8),
                  child: Progress(
                    message: 'Sending...',
                  ),
                ),
                visible: _sending,
              ),
              Text(
                widget.contact.name,
                style: TextStyle(
                  fontSize: 24.0,
                ),
              ),
              Padding(
                padding: const EdgeInsets.only(top: 16.0),
                child: Text(
                  widget.contact.accountNumber.toString(),
                  style: TextStyle(
                    fontSize: 32.0,
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
              Padding(
                padding: const EdgeInsets.only(top: 16.0),
                child: TextField(
                  controller: _valueController,
                  style: TextStyle(fontSize: 24.0),
                  decoration: InputDecoration(labelText: 'Value'),
                  keyboardType: TextInputType.numberWithOptions(decimal: true),
                ),
              ),
              Padding(
                padding: const EdgeInsets.only(top: 16.0),
                child: SizedBox(
                  width: double.maxFinite,
                  child: ElevatedButton(
                    child: Text('Transfer'),
                    onPressed: () {
                      final double? value =
                          double.tryParse(_valueController.text);
                      if (value == null) return;
                      showDialog(
                        context: context,
                        builder: (contextDialog) => TransactionAuthDialog(
                          onConfirm: (password) {
                            final transactionCreated = Transaction(
                                transactionId, value, widget.contact);
                            _save(transactionCreated, password,
                                context); //should pass as argument the screen content, not the dialog context
                          },
                        ),
                      );
                    },
                  ),
                ),
              )
            ],
          ),
        ),
      ),
    );
  }

  void _save(Transaction transactionCreated, String password,
      BuildContext context) async {
    setState(() {
      _sending = true;
    });

    await Future.delayed(Duration(seconds: 1));

    Transaction transaction = await _webClient
        .save(transactionCreated, password)
        .catchError((e) async {
      if (FirebaseCrashlytics.instance.isCrashlyticsCollectionEnabled) {
        FirebaseCrashlytics.instance.setCustomKey("exception", e.toString());
        FirebaseCrashlytics.instance
            .setCustomKey("http_body", transactionCreated.toString());
        await FirebaseCrashlytics.instance.recordError(e, null);
      }

      _showFailureMessage(context, 'Timeout submitting the transaction');
    }, test: (e) => e is TimeoutException).catchError((e) async {
      if (FirebaseCrashlytics.instance.isCrashlyticsCollectionEnabled) {
        FirebaseCrashlytics.instance.setCustomKey("exception", e.toString());
        FirebaseCrashlytics.instance
            .setCustomKey("http_body", transactionCreated.toString());
        await FirebaseCrashlytics.instance.recordError(e, null);
      }

      _showFailureMessage(context, e.message);
    }, test: (e) => e is HttpException).catchError((e) async {
      if (FirebaseCrashlytics.instance.isCrashlyticsCollectionEnabled) {
        FirebaseCrashlytics.instance.setCustomKey("exception", e.toString());
        FirebaseCrashlytics.instance
            .setCustomKey("http_body", transactionCreated.toString());
        await FirebaseCrashlytics.instance.recordError(e, null);
      }

      _showFailureMessage(context, 'Unknown error');
    }, test: (e) => e is Exception).whenComplete(() => setState(() {
              _sending = false;
            }));

    if (transaction != null) {
      await showDialog(
          context: context,
          builder: (contextDialog) {
            return SuccessDialog('Successful transaction');
          });
      Navigator.pop(context);
    }
  }

  void _showFailureMessage(BuildContext context, String message) {
/*
*     showDialog(
        context: context,
        builder: (contextDialog) {
          return FailureDialog(message);
        });
* */
  /*
  *   showDialog(
        context: context,
        builder: (_) => NetworkGiffyDialog(
              //image: Image(image: Image,),
              //imageUrl:,
              title: Text('Granny Eating Chocolate',
                  textAlign: TextAlign.center,
                  style:
                      TextStyle(fontSize: 22.0, fontWeight: FontWeight.w600)),
              description: Text(
                'This is a granny eating chocolate dialog box. This library helps you easily create fancy giffy dialog',
                textAlign: TextAlign.center,
              ),
              entryAnimation: EntryAnimation.BOTTOM_LEFT,
              onOkButtonPressed: () {},
            ));
  * */
    /*
ScaffoldMessenger.of(context).showSnackBar(SnackBar(
      content: Text(message),
    ),);
*/
    // showToast(message, gravity: Toast.BOTTOM);
  }

  void showToast(String msg, {int? duration, int? gravity}) {
    //Toast.show(msg, context, duration: duration!, gravity: gravity!);
  }
}
