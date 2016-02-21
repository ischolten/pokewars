package com.ddb.joanchen.pokewars;

import android.content.Intent;
import android.os.Bundle;
import android.app.Activity;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

public class RegisterActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);
        Intent intent = getIntent();
    }

    public void onClickRegister(View vew) {
        final EditText username = (EditText) findViewById(R.id.UsernameReg);
        final EditText password = (EditText) findViewById(R.id.PasswordReg);
        final EditText confirmPassword = (EditText) findViewById(R.id.PasswordConfirmReg);
        if(!password.getText().toString().equals(confirmPassword.getText().toString())) {
            Toast.makeText(this, "Password and Confirm Password must match. Please try again.", Toast.LENGTH_LONG).show();
        } else {
            Toast.makeText(this, ("Registered "+username.getText().toString()+". Please Login."), Toast.LENGTH_LONG).show();
            finish();
        }
    }



}
