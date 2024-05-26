package com.example.esemkapetitionv2

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import com.example.esemkapetitionv2.databinding.ActivityProfileBinding

class Activity_profile : AppCompatActivity() {
    lateinit var binding: ActivityProfileBinding
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        binding = ActivityProfileBinding.inflate(layoutInflater)
        setContentView(binding.root)


    }
}