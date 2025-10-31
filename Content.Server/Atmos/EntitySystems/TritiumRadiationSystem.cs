using Content.Server.Atmos.EntitySystems;
using Content.Server.Radiation.Systems;
using Content.Server.Radiation.Components;
using Content.Shared.Atmos;
using Robust.Shared.Map;
using Robust.Shared.GameObjects;
using Robust.Shared.Timing;

namespace Content.Server.Atmos;

/// <summary>
/// Applies radiation to nearby entities when tritium exists in nearby active atmos tiles.
/// </summary>

[UpdateAfter(typeof(AtmosphereSystem))]
public sealed class TritiumRadiationSystem : EntitySystem
{
	[Dependency] private readonly AtmosphereSystem _atmos = default!;
    [Dependency] private readonly RadiationSystem _radiation = default!;
    [Dependency] private readonly IEntityManager _entMan = default!;
    [Dependency] private readonly IGameTiming _timing = default!;

	private TimeSpan _nextUpdate;
	private const float UpdateInterval = 2.0f; // seconds
	private readonly Dictionary<EntityUid, RadiationSourceComponent> _virtualSources = new();

	// accumulate time until we exceed our interval, then run the mainloop
	// robust against tickrate variation because we're counting seconds here, not frames
	public override void Update(float frameTime)
	{
		if (_timing.TotalTime < _nextUpdate) return;

		_nextUpdate = _timing.TotalTime + TimeSpan.FromSeconds(UpdateInterval);
		MainLoop();
	}

	private void MainLoop() {
		// TODO: implement main loop thing

		// foreach (var grid in getallgrids())
			// var activetiles = getallactivetiles();
			// var tritium = activeTiles;
			// var tritiumTiles = activeTiles
				// .Where(tile => getMoles(tile, trit) >= Atmospherics.TritiumRadiationThreshold)
				// .ToList();
			// var clusters = ClusterTritiumTiles(tritiumTiles);
			// foreach (var cluster in clusters)
				// var rads = cluster.RadsPerSecond;
				// RADIATION???
		// for each active tile on that grid,
		// if the tile has no atmosphere, skip this tile
		// get the number of moles of tritium on that tile
		// if the number of moles is below a constant, skip this tile
		// cluster tiles together and sum their sources together
		// create a virtual radiation source every 1-2s using the clustered tiles' summed tritium mols
	}
	

	private List<TritiumCluster> ClusterTritiumTiles(List<EntityCoordinates> tiles) {
		// TODO: implement helper that clusters tritium tiles together

		// take a list of coordinates
		// for each coordinate
		// if we've visited it, skip it
		// if the tile has no atmosphere or the number of moles of tritium is below a constant, skip this tile
		// create a new cluster and initialize its coordinates as the current coordinates
		// merge neighbors (taken from the list of active tiles) within ClusterRadius
		// increment the rads of the cluster by the rads of the merged neighbor
		// mark the neighbor as visited
		// repeat until there are no more unvisited neighbors
		// return a list of clusters
	}

	private void ApplyClusterRads(TritiumCluster cluster) {
		// TODO: implement application of cluster rads

		// EntityUid uid = GetOrCreateVirtualSource();
		// var source = EnsureComp<RadiationSourceComponent>;
		// source.Enabled = true;
		// source.RadsPerSecond = cluster.RadsPerSecond;
		// coordinates = cluster.Tiles[0];
	}

	// i shouldn't have to explain this one
	private float CalculateRads(float moles) {
		return mols * Atmospherics.TritiumRadsPerMol;
	}

	private sealed class TritiumCluster
	{
		public List<EntityCoordinates> Tiles = new();
		public float RadsPerSecond;
	}
}