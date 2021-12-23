import 'package:firstapi/components/editor.dart';
import 'package:firstapi/models/transfer.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class TransferForm extends StatelessWidget {
  final TextEditingController _accountNumberFieldController =
      TextEditingController();
  final TextEditingController _valueFieldController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text("Transfer form"),
        ),
        body: SingleChildScrollView(
          child: Column(
            children: [
              Editor(
                label: "Account Number",
                hint: "000000",
                controller: _accountNumberFieldController,
              ),
              Editor(
                  label: "Value",
                  hint: "00.00",
                  controller: _valueFieldController,
                  icon: Icons.monetization_on),
              ElevatedButton(
                  onPressed: () => createTransfer(context),
                  child: Text("Confirm"))
            ],
          ),
        ));
  }

  void createTransfer(BuildContext context) {
    final double? value = double.tryParse(_valueFieldController.text);
    final int? accountNumber = int.tryParse(_accountNumberFieldController.text);
    if (value != null && accountNumber != null) {
      final createdTransfer = Transfer(value, accountNumber);

      Navigator.pop(context, createdTransfer);
    }
  }
}
