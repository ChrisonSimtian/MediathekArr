using MediathekArr.Tests.Fixtures;

namespace MediathekArr.Tests;

public abstract class MediathekArrApiIntegratedUnitTest(MediathekArrApiWebApplicationFactory factory) : AbstractIntegratedUnitTest<MediathekArrApiWebApplicationFactory, Program>(factory);