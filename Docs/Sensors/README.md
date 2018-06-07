PositioningSystem: {
    Receiver: {
        location: vec2
    },
}

Radar: {
	Transmitter: {
		maxPower: int,
		rechargeRate: float,
		wavePattern: [
            power: float,
        ],
	},
	Receiver: {
        filters: [
            id: int,
        ],
        echoes: [
            objectId: int,
            timeOfFlight: float,
        ],
	},
}
