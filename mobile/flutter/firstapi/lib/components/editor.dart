
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class Editor extends StatelessWidget {
  final String? label;
  final String? hint;
  final TextEditingController? controller;
  final IconData? icon;

  Editor(
      {required this.label,
        required this.hint,
        required this.controller,
        this.icon});

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.all(16.0),
      child: TextField(
        controller: controller,
        style: const   TextStyle(
          fontSize: 24,
        ),
        decoration: InputDecoration(
            labelText: label,
            hintText: hint,
            icon: icon != null ? Icon(icon) : null),
        keyboardType: TextInputType.number,
      ),
    );
  }
}