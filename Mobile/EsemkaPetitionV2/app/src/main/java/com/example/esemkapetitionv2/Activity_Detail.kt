package com.example.esemkapetitionv2

import android.app.Activity
import android.content.Context
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.widget.Toast
import com.example.esemkapetitionv2.databinding.ActivityDetailBinding
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.launch
import org.json.JSONObject
import java.net.HttpURLConnection
import java.net.URL

class Activity_Detail : AppCompatActivity() {
    lateinit var binding: ActivityDetailBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityDetailBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.detailToolbar.setNavigationOnClickListener{
            setResult(Activity.RESULT_OK, Intent())
            finish()
        }

        val id = intent.getStringExtra("petID")

        GlobalScope.launch(Dispatchers.IO){

            val conn = URL("http://10.0.2.2:5000/petition").openStream().bufferedReader().readText()
            val jsons = JSONObject(conn)

            runOnUiThread {
                binding.NameTitle.text = jsons.getString("title")
                binding.detailCreator.text = jsons.getString("creatorName")
                binding.detailDesc.text = jsons.getString("description")

                binding.signedBy.text = "Signed by ${jsons.getString("totalSigners")} people"
                binding.singnIn.text = "${jsons.getString("target")} more to go"

            }
        }

        var creatorid = this.getSharedPreferences("random", Context.MODE_PRIVATE).getString("user", "{}")
        var arrays = JSONObject(creatorid);

        GlobalScope.launch(Dispatchers.IO){
            val conn = URL("http://10.0.2.2:5000/petition/${id.toString()}/is-signed?signerID=${arrays.getString("userID")}").openStream().bufferedReader().readText()
            Log.d("oke",conn)

            if(JSONObject(conn).getBoolean("Issgined")== false){
                binding.singnIn.setText("setText")
            }
            else{
                binding.singnIn.setText("signed")
            }
        }


        binding.singnIn.setOnClickListener {

            GlobalScope.launch(Dispatchers.IO){
                val conn = URL("").openConnection() as HttpURLConnection
                conn.requestMethod ="POST"
                conn.setRequestProperty("Content-Type","application/json")

                val jsons = JSONObject().apply {
                    put("signerID", arrays.getString("userID"))
                }


                conn.outputStream.write(jsons.toString().toByteArray())

                if (conn.responseCode in 200..299) {
                    runOnUiThread {
                        binding.singnIn.setText("Signed")
                    }
                }
                else {
                    runOnUiThread {
                        Toast.makeText(this@Activity_Detail, "${conn.errorStream.bufferedReader().readText()}", Toast.LENGTH_SHORT).show()
                    }
                }


            }


        }


    }
}