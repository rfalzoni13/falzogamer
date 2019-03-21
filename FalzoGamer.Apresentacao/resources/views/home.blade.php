@extends('layouts.app')

@section('title', 'Título Laravel')

@section('navbar')

    @parent

@endsection

@section('content')
    {{ $response[0]['Nome'] }}
@endsection