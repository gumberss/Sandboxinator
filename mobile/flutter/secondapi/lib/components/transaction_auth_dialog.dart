import 'package:flutter/material.dart';

class TransactionAuthDialog extends StatefulWidget {
  final Function(String password) onConfirm;

  TransactionAuthDialog({required this.onConfirm});

  @override
  State<TransactionAuthDialog> createState() => _TransactionAuthDialogState();
}

class _TransactionAuthDialogState extends State<TransactionAuthDialog> {
  final TextEditingController _passwordController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text('Authenticate'),
      content: TextField(
        controller: _passwordController,
        obscureText: true,
        maxLength: 4,
        textAlign: TextAlign.center,
        decoration: InputDecoration(border: OutlineInputBorder()),
        keyboardType: TextInputType.number,
        style: TextStyle(fontSize: 32, letterSpacing: 32),
      ),
      actions: [
        TextButton(onPressed: () {
          Navigator.pop(context);
        }, child: Text('Cancel')),
        TextButton(
            onPressed: () {
              widget.onConfirm(_passwordController.text);
              Navigator.pop(context);
            },
            child: Text('Confirm'))
      ],
    );
  }
}
