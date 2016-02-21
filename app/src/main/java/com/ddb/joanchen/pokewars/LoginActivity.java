package com.ddb.joanchen.pokewars;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.app.Activity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.google.android.gms.appindexing.Action;
import com.google.android.gms.appindexing.AppIndex;
import com.google.android.gms.common.api.GoogleApiClient;

public class LoginActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        Button loginButton = (Button) findViewById(R.id.LoginButton);
        Button registerButton = (Button) findViewById(R.id.RegisterButton);
    }


    public void onClickLoginScreen(View view) {
        Intent intent;
            switch(view.getId()){
            case R.id.LoginButton:
                // gets username and password from edit boxes
                final EditText username = (EditText) findViewById(R.id.Username);
                final EditText password = (EditText) findViewById(R.id.Password);
                // displays that the user logged in as the user
                Toast.makeText(this, ("Logged in as " + username.getText().toString()), Toast.LENGTH_LONG).show();
                // create intent for changing pages
                startActivity(new Intent(this, HomeActivity.class));
                break;
            case R.id.RegisterButton:
                // create intent for changing pages
                startActivity(new Intent(this, RegisterActivity.class));
                break;

        }
    }
}
